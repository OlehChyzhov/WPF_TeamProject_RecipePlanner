// <copyright file="StatisticsViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserInterface.MVVM
{
    using BusinessLogic;
    using DataAccess;
    using DataAccess.Models;
    using LiveCharts;
    using LiveCharts.Defaults;
    using LiveCharts.Wpf;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Media;
    using UserInterface.MVVM.Commands.StatisticsCommands;

    /// <summary>
    /// Statistics view model.
    /// </summary>
    public class StatisticsViewModel : BaseViewModel
    {
        private LogWriter logWriter = new LogWriter("../../../Logs/statistic.log");

        private string userEmail = AccountManager.LoginedAccount.Email;

        private ZoomingOptions zoomingMode = ZoomingOptions.None;
        private double? xMinValue = double.NaN;
        private double? xMaxValue = double.NaN;
        private double? yMinValue = double.NaN;
        private double? yMaxValue = double.NaN;

        private SeriesCollection series = new SeriesCollection();
        private DateTime? fromDateTime;
        private DateTime? toDateTime;

        private StatisticEntity? selectedEntity;
        private string date = DateOnly.FromDateTime(DateTime.Now).ToString();
        private string weight = "0";

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsViewModel"/> class.
        /// </summary>
        public StatisticsViewModel()
        {
            // Statistics Page
            this.XFormatter = (val) =>
            {
                try
                {
                    DateTime dateTime = new DateTime((long)val);
                    return DateOnly.FromDateTime(dateTime).ToString();
                }
                catch
                {
                    return "None";
                }
            };
            this.YFormatter = (val) =>
            {
                try
                {
                    return $"{val} kg";
                }
                catch
                {
                    return "None";
                }
            };

            this.ResetZoomingModeCommand = new ResetZoomingModeCommand(this);
            this.ToggleZoomingModeCommand = new ToggleZoomingModeCommand(this);
            this.ManageEntitiesCommand = new ManageEntitiesCommand(this);
            this.DatePickerChangedCommand = new DatePickerChangedCommand(this);

            try
            {
                ChartValues<DateTimePoint> weightStatistics = this.GetTimeData();
                this.AddNewSerie(Colors.Blue, "Weights", weightStatistics);
            }
            catch
            {
            }

            // Manage Entities Page
            this.Entities = new ObservableCollection<StatisticEntity>();
            this.PopulateEntities();

            this.AddNewEntityCommand = new AddNewEntityCommand(this);
            this.RemoveSelectedEntityCommand = new RemoveSelectedEntityCommand(this);
        }

        /// <summary>
        /// Gets or sets min x value.
        /// </summary>
        public double? XMin
        {
            get => this.xMinValue;
            set
            {
                this.xMinValue = value;
                this.OnPropertyChanged(nameof(this.XMin));
            }
        }

        /// <summary>
        /// Gets or sets max x value.
        /// </summary>
        public double? XMax
        {
            get => this.xMaxValue;
            set
            {
                this.xMaxValue = value;
                this.OnPropertyChanged(nameof(this.XMax));
            }
        }

        /// <summary>
        /// Gets or sets min y value.
        /// </summary>
        public double? YMin
        {
            get => this.yMinValue;
            set
            {
                this.yMinValue = value;
                this.OnPropertyChanged(nameof(this.YMin));
            }
        }

        /// <summary>
        /// Gets or sets max y value.
        /// </summary>
        public double? YMax
        {
            get => this.yMaxValue;
            set
            {
                this.yMaxValue = value;
                this.OnPropertyChanged(nameof(this.YMax));
            }
        }

        /// <summary>
        /// Gets or sets user email.
        /// </summary>
        public string UserEmail
        {
            get => this.userEmail;
            set
            {
                this.userEmail = value;
                this.OnPropertyChanged(nameof(this.UserEmail));
            }
        }

        /// <summary>
        /// Gets or sets x axis as dates.
        /// </summary>
        public Func<double, string> XFormatter { get; set; }

        /// <summary>
        /// Gets or sets x axis as kilograms.
        /// </summary>
        public Func<double, string> YFormatter { get; set; }

        /// <summary>
        /// Gets or sets zooming mode.
        /// </summary>
        public ZoomingOptions ZoomingMode
        {
            get => this.zoomingMode;
            set
            {
                this.zoomingMode = value;
                this.OnPropertyChanged(nameof(this.ZoomingMode));
            }
        }

        /// <summary>
        /// Gets or sets series to display.
        /// </summary>
        public SeriesCollection Series
        {
            get => this.series;
            set
            {
                this.series = value;
                this.OnPropertyChanged(nameof(this.Series));
            }
        }

        /// <summary>
        /// Gets or sets the beginning of the statistics.
        /// </summary>
        public DateTime? FromDateTime
        {
            get => this.fromDateTime;
            set
            {
                this.fromDateTime = value;
                this.OnPropertyChanged(nameof(this.FromDateTime));
            }
        }

        /// <summary>
        /// Gets or sets the end of the statistics.
        /// </summary>
        public DateTime? ToDateTime
        {
            get => this.toDateTime;
            set
            {
                this.toDateTime = value;
                this.OnPropertyChanged(nameof(this.ToDateTime));
            }
        }

        /// <summary>
        /// Gets or sets user entities.
        /// </summary>
        public ObservableCollection<StatisticEntity> Entities { get; set; }

        /// <summary>
        /// Gets or sets the entity selected by user.
        /// </summary>
        public StatisticEntity? SelectedEntity
        {
            get => this.selectedEntity;
            set
            {
                this.selectedEntity = value;
                this.OnPropertyChanged(nameof(this.SelectedEntity));
            }
        }

        /// <summary>
        /// Gets or sets the date to add in statistics entities.
        /// </summary>
        public string Date
        {
            get => this.date;
            set
            {
                this.date = value;
                this.OnPropertyChanged(nameof(this.Date));
            }
        }

        /// <summary>
        /// Gets or sets the weight to add in statistics entities.
        /// </summary>
        public string Weight
        {
            get => this.weight;
            set
            {
                this.weight = value;
                this.OnPropertyChanged(nameof(this.Weight));
            }
        }

        /// <summary>
        /// Gets reset zooming mode method.
        /// </summary>
        public ResetZoomingModeCommand ResetZoomingModeCommand { get; }

        /// <summary>
        /// Gets toggle zooming mode method.
        /// </summary>
        public ToggleZoomingModeCommand ToggleZoomingModeCommand { get; }

        /// <summary>
        /// Gets manage entities method.
        /// </summary>
        public ManageEntitiesCommand ManageEntitiesCommand { get; }

        /// <summary>
        /// Gets date picker changed method.
        /// </summary>
        public DatePickerChangedCommand DatePickerChangedCommand { get; }

        /// <summary>
        /// Gets add new entity method.
        /// </summary>
        public AddNewEntityCommand AddNewEntityCommand { get; }

        /// <summary>
        /// Gets remove selected entity method.
        /// </summary>
        public RemoveSelectedEntityCommand RemoveSelectedEntityCommand { get; }

        /// <summary>
        /// Changes zoom mode.
        /// </summary>
        public void ExecuteToggleZoomModeCommand()
        {
            switch (this.ZoomingMode)
            {
                case ZoomingOptions.None:
                    this.ZoomingMode = ZoomingOptions.X;
                    break;
                case ZoomingOptions.X:
                    this.ZoomingMode = ZoomingOptions.Y;
                    break;
                case ZoomingOptions.Y:
                    this.ZoomingMode = ZoomingOptions.Xy;
                    break;
                case ZoomingOptions.Xy:
                    this.ZoomingMode = ZoomingOptions.None;
                    break;
            }
        }

        /// <summary>
        /// Resets displayed statistics.
        /// </summary>
        public void ExecuteResetZoomCommand()
        {
            this.XMin = double.NaN;
            this.XMax = double.NaN;
            this.YMin = double.NaN;
            this.YMax = double.NaN;
            this.FromDateTime = null;
            this.ToDateTime = null;
        }

        /// <summary>
        /// Shows manage entities page.
        /// </summary>
        public void ExecuteManageEntitiesCommand()
        {
            App.MyManageEntitesPage.DataContext = this;
            App.RightSideFrame.Navigate(App.MyManageEntitesPage);
        }

        /// <summary>
        /// When selected datepickers resets the livechart.
        /// </summary>
        public void ExecuteDatePickerChangedCommand()
        {
            this.ResetLiveChart(this.FromDateTime, this.ToDateTime);
        }

        /// <summary>
        /// Shows all entities the user has.
        /// </summary>
        public void PopulateEntities()
        {
            this.Entities.Clear();
            foreach (StatisticEntity entity in AccountManager.LoginedAccount.StatisticEntities!.OrderBy(entity => entity.Date))
            {
                this.Entities.Add(entity);
            }
        }

        /// <summary>
        /// Removes the entity selected by the user.
        /// </summary>
        public void ExecuteRemoveSelectedEntityCommand()
        {
            try
            {
                StatisticEntity entity = DbHelper.db.StatisticEntities.First(entity => entity.Id == this.SelectedEntity!.Id);
                DbHelper.db.Remove(entity);
                DbHelper.db.SaveChanges();
                this.PopulateEntities();
                this.ResetLiveChart();
                this.ResetCurrentWeight();
            }
            catch
            {
                this.logWriter.Write("RemoveSelectedEntity: Remove Failure");
            }
        }

        /// <summary>
        /// Adds new entity to the user entities.
        /// </summary>
        public void ExecuteAddNewEntityCommand()
        {
            try
            {
                StatisticEntity entity = new StatisticEntity()
                {
                    AccountEmail = AccountManager.LoginedAccount.Email,
                    Date = DateTime.Parse(this.Date),
                    Weight = int.Parse(this.Weight),
                };
                DbHelper.db.StatisticEntities.Add(entity);
                DbHelper.db.SaveChanges();
                try
                {
                    this.PopulateEntities();
                    this.ResetLiveChart();
                    this.ResetCurrentWeight();
                }
                catch
                {
                }
            }
            catch
            {
                MessageBox.Show("Error. Insert valid values", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.logWriter.Write("AddNewEntity: Invalid values");
            }
        }

        /// <summary>
        /// When added new statistic entity sets new current weight to the latest one.
        /// </summary>
        public void ResetCurrentWeight()
        {
            int maxWeight = AccountManager.LoginedAccount.StatisticEntities!.OrderByDescending(ent => ent.Weight).First().Weight;
            AccountManager.LoginedAccount.AccountInfo.Weight = maxWeight;
            DbHelper.db.AccountInformations.Update(AccountManager.LoginedAccount.AccountInfo);
            DbHelper.db.SaveChanges();
        }

        private void AddNewSerie(Color color, string title, ChartValues<DateTimePoint> values)
        {
            LinearGradientBrush brush = new LinearGradientBrush()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0, 1),
            };
            brush.GradientStops.Add(new GradientStop(color, 0));
            brush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));

            this.Series.Add(new LineSeries()
            {
                Title = title,
                Values = values,
                Fill = brush,
            });
        }

        private void ResetLiveChart(DateTime? from = null, DateTime? to = null)
        {
            this.Series.Clear();
            ChartValues<DateTimePoint> weightStatistics;
            if ((from == null && to == null) || (from != null && to == null) || (from == null && to != null))
            {
                weightStatistics = this.GetTimeData();
            }
            else
            {
                weightStatistics = this.GetTimeData(from, to);
            }

            this.AddNewSerie(Colors.Blue, "Weights", weightStatistics);
        }

        private ChartValues<DateTimePoint> GetTimeData(DateTime? from = null, DateTime? to = null)
        {
            ChartValues<DateTimePoint> valuesPoints = new ChartValues<DateTimePoint>();
            List<StatisticEntity> entities;
            if ((from == null && to == null) || (from != null && to == null) || (from == null && to != null))
            {
                entities = AccountManager.LoginedAccount.StatisticEntities!.OrderBy(entity => entity.Date).ToList();
            }
            else
            {
                entities = AccountManager.LoginedAccount.StatisticEntities!.OrderBy(entity => entity.Date)
                    .Where(entity => entity.Date > from && entity.Date < to).ToList();
            }

            foreach (StatisticEntity entity in entities)
            {
                valuesPoints.Add(new DateTimePoint(entity.Date, entity.Weight));
            }

            return valuesPoints;
        }
    }
}

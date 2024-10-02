namespace WPF.ViewModels;

public class DetailsViewModel : NotifyPropertyChangedBase, IDisposable
{
    private readonly CoinCapService coinCapService;

    private Paint axisTextColor;
    public Paint AxisTextColor
    {
        get => axisTextColor;
        set
        {
            axisTextColor = value;
            OnPropertyChanged(nameof(AxisTextColor));
        }
    }

    public ISeries[] Series { get; set; }
    public Axis[] XAxes { get; set; }
    public Axis[] YAxes { get; set; }

    public Currency SelectedCurrency { get; }

    public DetailsViewModel(Currency selectedCurrency)
    {
        SelectedCurrency = selectedCurrency;
        coinCapService = new CoinCapService();
        Task.Run(() => LoadDataAsync(selectedCurrency.Id));
        MainWindow.ThemeChanged += OnThemeChanged;
        UpdateTextColor(ThemeManager.Current.ApplicationTheme);
    }

    private void OnThemeChanged(object sender, ApplicationTheme? theme)
    {
        UpdateTextColor(theme);
    }

    public async Task LoadDataAsync(string assetId)
    {
        var historyData = await coinCapService.GetAssetHistoryAsync(assetId, "d1");
        var prices = historyData.Select(h => double.Parse(h.PriceUsd, CultureInfo.InvariantCulture)).ToArray();
        var times = historyData.Select(h => DateTimeOffset.FromUnixTimeMilliseconds(h.Time)
                                                   .UtcDateTime
                                                   .AddHours(3)
                                                   .ToString("dd MMM yyyy", CultureInfo.InvariantCulture))
                                                   .ToArray();

        Series =
        [
            new LineSeries<double>
            {
                Values = prices,
                Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 2 },
                Fill = null,
                GeometrySize = 1.5,
            }
        ];

        XAxes =
        [
            new Axis
            {
                Labels = times,
                LabelsRotation = 15,
                Name = "Date",
                NamePaint = AxisTextColor,
                LabelsPaint = AxisTextColor,
                TicksPaint = new SolidColorPaint(SKColors.Blue),
                TextSize = 12
            }
        ];

        YAxes =
        [
            new Axis
            {
                Name = "Price (USD)",
                NamePaint = AxisTextColor,
                LabelsPaint = AxisTextColor,
                TicksPaint = new SolidColorPaint(SKColors.Blue),
                TextSize = 12
            }
        ];

        OnPropertyChanged(nameof(Series));
        OnPropertyChanged(nameof(XAxes));
        OnPropertyChanged(nameof(YAxes));
    }

    public void UpdateTextColor(ApplicationTheme? theme)
    {
        if (theme == ApplicationTheme.Dark)
        {
            AxisTextColor = new SolidColorPaint(SKColors.White);
        }
        else
        {
            AxisTextColor = new SolidColorPaint(SKColors.Black);
        }

        if (XAxes != null && YAxes != null)
        {
            foreach (var axis in XAxes)
            {
                axis.LabelsPaint = AxisTextColor;
                axis.NamePaint = AxisTextColor;
            }

            foreach (var axis in YAxes)
            {
                axis.LabelsPaint = AxisTextColor;
                axis.NamePaint = AxisTextColor;
            }
        }

        OnPropertyChanged(nameof(XAxes));
        OnPropertyChanged(nameof(YAxes));
    }


    public void Dispose()
    {
        MainWindow.ThemeChanged -= OnThemeChanged;
    }
}

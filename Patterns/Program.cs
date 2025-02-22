using Abstract_Factory;
using Adapter;
using Decorator;
using Facade;
using Factory;
using Iterator;
using Observer;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;

static void FactoryMethod()
{
    IMessage message;

    Console.WriteLine("Enter 0 for Email or 1 for SMS: ");
    string input = Console.ReadLine();
    int number = int.Parse(input);

    if (number == 0)
    {
        MessageCreator emailFactory = new EmailMessageCreator();
        message = emailFactory.CreateMessage();
        message.Send("JotaroKujo@gmail.com", "Dio@gmail.com", "Ora Ora");
    }
    else if (number == 1)
    {
        MessageCreator smsFactory = new SMSMessageCreator();
        message = smsFactory.CreateMessage();
        message.Send("+380 96 763 6610", "380 96 333 5555", "Doppio");
    }
    else
    {
       return;
    }
}

static void AbstractFactory()
{
    IWeaponFactory factory;
    Console.WriteLine("Enter 0 for Fire Weapon or 1 for Ice Weapon: ");
    sbyte input = sbyte.Parse(Console.ReadLine());
    if (input == 0)
    {
        factory = new FireWeaponFactory();
    }
    else if (input == 1)
    {
        factory = new IceWeaponFactory();
    }
    else
    {
        return;
    }
    WeaponService service = new WeaponService(factory);
    service.CreateSword();
    service.CreateMagicStuff();
    service.HitWithSword(100);
    service.UseMagicStuff(100, 10);
}

static void Adapter()
{
    TempDataFahrenheit tempDataFahrenheit = new TempDataFahrenheit(100,120);
    FahrenheitToCelsiusAdapter adapter = new FahrenheitToCelsiusAdapter(tempDataFahrenheit);
    HeatCalculator heatCalculator = new HeatCalculator(4200, 1);
    var result= heatCalculator.CalculateHeat(adapter);
    
}

static void Decorator()
{

    ReportGenerator reportGenerator = new ReportGenerator();
    string path = @"D:\my_projects\data\";

    reportGenerator.GenerateReport($"{path}test1", "Hello, world!");

    PDFReportDecorator pdfReportDecorator = new PDFReportDecorator(reportGenerator);
    pdfReportDecorator.GenerateReport($"{path}test2", "Hello, world!");

    ExcelReportDecorator excelReportDecorator = new ExcelReportDecorator(pdfReportDecorator);
    excelReportDecorator.GenerateReport($"{path}test3", "Hello, world!");

}

static void Observer()
{
    WeatherData weatherData_1 = new WeatherData(-3, 71, 768);
    WeatherReporter weatherReporter_1 = new WeatherReporter("WeatherReporter 1");
    WeatherReporter weatherReporter_2 = new WeatherReporter("WeatherReporter 2");

    WeatherTracker weatherTracker = new WeatherTracker();

    weatherReporter_1.Subscribe(weatherTracker);
    weatherTracker.TrackWeather(weatherData_1);

    weatherReporter_2.Subscribe(weatherTracker);

    WeatherData weatherData_2 = new WeatherData(-5, 65, 770);
    weatherTracker.TrackWeather(weatherData_2);

    weatherReporter_1.OnCompleted();

    weatherTracker.EndTransmission();
}

static void Iterator()
{
    string directoryPath = "G:/SteamLibrary";
    FileCollection fileCollection = new FileCollection(directoryPath);
    foreach (var file in fileCollection)
    {
        Console.WriteLine(file);
    }

}

static void Facade()
{

    OrderFacade orderFacade = new OrderFacade(20);
    Customer customer1 = new Customer("Іван", "Київ, вул. Хрещатик, 1", 60000);
    Customer customer2 = new Customer("Марія", "Львів, вул. Франка, 10", 60000);
    Product product1 = new Product("Ноутбук ASUS TUF Gaming A17", 53000, 1);
    Product product2 = new Product("Мобільний телефон Apple iPhone 16 Pro 256GB", 57999, 2);


    orderFacade.PlaceOrder(customer1, product1);
    orderFacade.PlaceOrder(customer2, product2);
}


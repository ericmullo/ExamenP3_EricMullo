
using ExamenP3_EricMullo.Repositories;

namespace ExamenP3_EricMullo
{
    public partial class App : Application
    {
        public static AirportRepository AeropuertoRepository { get; private set; }
        public static APIRepository _APIRepository { get; private set; }

        public App(AirportRepository AirportRepository, APIRepository APIRepository)
        {
            InitializeComponent();
            AeropuertoRepository = AirportRepository;
            _APIRepository = APIRepository;
            MainPage = new AppShell();
        }
    }
}

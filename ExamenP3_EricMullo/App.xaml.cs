
using ExamenP3_EricMullo.Repositories;

namespace ExamenP3_EricMullo
{
    public partial class App : Application
    {
        public static AirportRepository _AeropuertoRepository { get; private set; }
        public static APIRepository _APIRepository { get; private set; }

        public App(AirportRepository AirportRepository, APIRepository APIRepository)
        {
            InitializeComponent();
            _AeropuertoRepository = AirportRepository;
            _APIRepository = APIRepository;
            MainPage = new AppShell();
        }
    }
}

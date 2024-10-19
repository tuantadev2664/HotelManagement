using BusinessObjects;
using DataAccess.DAO;
using DataAccess.Repository;
using DataAccessObjects;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSApp
{
    public class DIService
    {
        private static DIService instance = null;
        private static readonly object lockObject = new object();
        private ServiceProvider serviceProvider;
        public ServiceProvider ServiceProvider => serviceProvider;

        public static DIService Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new DIService();
                    }
                }
                return instance;
            }
        }

        public DIService()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureService(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureService(ServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>();

            services.AddSingleton<CustomerDAO>();
            services.AddSingleton<RoomInformationDAO>();
            services.AddSingleton<RoomTypeDAO>();
            services.AddSingleton<BookingDetailDAO>();
            services.AddSingleton <BookingReservationDAO>();

            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IRoomInformationRepository, RoomInformationRepository>();
            services.AddSingleton<IRoomTypeRepository, RoomTypeRepository>();
            services.AddSingleton<IBookingDetailRepository, BookingDetailRepository>();
            services.AddSingleton<IBookingReservationRepository, BookingReservationRepository>();
        }
    }
}

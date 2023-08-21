﻿using Core.Persistence.Repositories;
namespace Domain.Entities
{
    public class Model : Entity<Guid>
    {
        public Guid BrandId { get; set; }
        public Guid FueldId { get; set; }
        public Guid TransmissionId { get; set; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual Fuel? Fuel { get; set; }
        public virtual Transmission? Transmission { get; }

        public virtual ICollection<Car> Cars { get; set; }

        public Model()
        {
            Cars = new HashSet<Car>();
        }

        public Model(Guid id, Guid brandId, Guid fuelId, Guid transmissionransId, string name, decimal dailyPrice,
            string imageUrl) : this()
        {
            Id = id;
            BrandId = brandId;
            FueldId = fuelId;
            TransmissionId = transmissionransId;
            Name = name;
            DailyPrice = dailyPrice;
            ImageUrl = imageUrl;
        }

    }

}
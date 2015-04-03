namespace HotelSystemApp.Interfaces
{
    using System.Collections.Generic;
    using HotelSystemApp.Enumerations;

    public interface IFeatures
    {
        List<Features> AllFeaturesInRoom { get; set; }

        void AddFeature(Features someFeature);

        void RemoveFeature(Features someFeature);
    }
}

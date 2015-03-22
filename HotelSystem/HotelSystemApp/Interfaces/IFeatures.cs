using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelSystemApp
{
    public interface IFeatures
    {
        List<Features> AllFeaturesInRoom { get; }

        void AddFeature(Features someFeature);

        void RemoveFeature(Features someFeature);
    }
}

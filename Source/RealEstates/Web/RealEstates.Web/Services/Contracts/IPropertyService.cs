namespace RealEstates.Web.Services.Contracts
{
    using Data.Models;
    using RealEstates.Web.Models.Properties;
    using System.Collections.Generic;

    public interface IPropertyService
    {
        PropertyDetailsViewModel PropertyDetails(int id);

        IList<MyAdsViewModel> GetMyAds(string currentUser);

        Property CreateProperty(AddPropertyViewModel model, string currentUser);

        Property CreateProperty(Property model, string currentUser);
    }
}
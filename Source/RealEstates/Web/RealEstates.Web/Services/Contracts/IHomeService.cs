namespace RealEstates.Web.Services.Contracts
{
    using Models.Home;
    using System.Collections.Generic;

    public interface IHomeService
    {
        IList<PropertyViewModel> GetHomeViewModel(string property);

        IList<PropertyViewModel> GetAllHomeViewModel();
    }
}
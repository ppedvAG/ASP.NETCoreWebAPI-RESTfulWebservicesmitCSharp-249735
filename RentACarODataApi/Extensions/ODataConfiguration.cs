using BusinessModel.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

namespace RentACarODataApi.Extensions;

public static class ODataConfiguration
{
    public static IMvcBuilder AddODataConfiguration(this IMvcBuilder builder)
    {
        var modelBuilder = new ODataConventionModelBuilder();
        modelBuilder.EntitySet<Auto>("Vehicles");
        modelBuilder.EntitySet<Order>("Orders");
        modelBuilder.EntitySet<Customer>("Customers");
        modelBuilder.EntityType<Order>().HasMany(o => o.Items);

        builder.AddOData(options => options
            .Select()
            .Filter()
            .OrderBy()
            .Expand()
            .Count()
            .SetMaxTop(20)
            .AddRouteComponents("odata", modelBuilder.GetEdmModel())
            );

        return builder;
    }
}

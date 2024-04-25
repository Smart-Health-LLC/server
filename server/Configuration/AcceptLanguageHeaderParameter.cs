using NJsonSchema;
using NSwag;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace server.Configuration;

public class AcceptLanguageHeaderParameter : IOperationProcessor
{
    public bool Process(OperationProcessorContext context)
    {
        var parameter = new OpenApiParameter
        {
            Name = "Accept-Language",
            Kind = OpenApiParameterKind.Header,
            Description = "Language preference for the response.",
            IsRequired = false,
            IsNullableRaw = true,
            Default = SupportedCultures.DefaultCulture.Name,
            Schema = new JsonSchema
            {
                Type = JsonObjectType.String,
                Item = new JsonSchema { Type = JsonObjectType.String }
            }
        };

        foreach (var culture in SupportedCultures.Cultures) parameter.Schema.Enumeration.Add(culture.Name);
        context.OperationDescription.Operation.Parameters.Add(parameter);
        return true;
    }
}

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
            IsRequired = true,
            IsNullableRaw = true,
            Default = SupportedLanguages.English.Codes.First(),
            Schema = new JsonSchema
            {
                Type = JsonObjectType.String,
                Item = new JsonSchema { Type = JsonObjectType.String }
            }
        };
        parameter.Schema.Enumeration.Add(SupportedLanguages.English.Codes.First());
        parameter.Schema.Enumeration.Add(SupportedLanguages.Russian.Codes.First());
        parameter.Schema.Enumeration.Add(SupportedLanguages.French.Codes.First());
        context.OperationDescription.Operation.Parameters.Add(parameter);
        return true;
    }
}

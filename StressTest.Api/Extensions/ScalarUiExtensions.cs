namespace StressTest.Api.Extensions;

public static class ScalarUiExtensions
{
    public static void MapScalarUi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/scalar/{documentName}", (string documentName) =>
        {
            var scalarScript = $$"""
                                 <!doctype html>
                                 <html>
                                 <head>
                                     <title>Scalar API Reference -- {{documentName}}</title>
                                     <meta charset="utf-8" />
                                     <meta
                                     name="viewport"
                                     content="width=device-width, initial-scale=1" />
                                 </head>
                                 <body>
                                     <script
                                     id="api-reference"
                                     data-url="/swagger/{{documentName}}/swagger.json"></script>
                                     <script>
                                     var configuration = {
                                         theme: 'purple',
                                     }
                                 
                                     document.getElementById('api-reference').dataset.configuration =
                                         JSON.stringify(configuration)
                                     </script>
                                     <script src="https://cdn.jsdelivr.net/npm/@scalar/api-reference"></script>
                                 </body>
                                 </html>
                                 """;

            return Results.Content(scalarScript, "text/html");
        }).ExcludeFromDescription();
    }
}
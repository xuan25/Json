# Json

Single file Json parser and serializer

```C#
Json.Value.Object rootObject = new Json.Value.Object()
{
    { "count", 4 },
    { "items",
        new Json.Value.Array()
        {
            new Json.Value.Object()
            {
                { "id", 1 },
                { "ip", "8.8.8.8" },
                { "provider", "Google" },
            },
            new Json.Value.Object()
            {
                { "id", 2 },
                { "ip", "8.8.4.4" },
                { "provider", "Google" },
            },
            new Json.Value.Object()
            {
                { "id", 3 },
                { "ip", "1.1.1.1" },
                { "provider", "Cloudflare" },
            },
            new Json.Value.Object()
            {
                { "id", 4 },
                { "ip", "1.0.0.1" },
                { "provider", "Cloudflare" },
            },
        }
    }
};

string jsonStr = rootObject.ToString();

Json.Value parsedObject = Json.Parser.Parse(jsonStr);
```

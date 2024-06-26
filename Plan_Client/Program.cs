﻿using static ApiConductorClient;

class MyConversation : ApiConductorClient.Conversation
{
    public MyConversation(ApiConductorClient client, string code) : base(client, code) { }

    protected override void on_return(object value)
    {
        Console.WriteLine($"on_return {value}");
    }

    protected override void on_complete()
    {
        Console.WriteLine($"on_complete");
    }

    protected override void on_new_code(string code)
    {
        Console.WriteLine($"on_new_code: {code}");
    }

    protected override void on_exception(string exc)
    {
        Console.WriteLine($"on_exception {exc}");
    }

    [ManagedFunction]
    public int search_email(int a = 0, int b = 0, int c = 0)
    {
        return a + 100;
    }

    [ManagedFunction]
    public int search_teams(int a = 0, int b = 0, int c = 0)
    {
        return a + 100;
    }

    [ManagedFunction]
    public int search_meetings(int a = 0, int b = 0, int c = 0)
    {
        return a + 100;
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        var config = new ApiConductorClient.Config
        {
            //  the following modules cannot be specified in a import or import from statement.
            // any other module either in the standard distribution or installed on the server can
            // be used.  if you don't trust any module, disable the import and import from statements
            ModuleBlacklist = new List<string> { "io", "sockets", "sys" },

            // below are all the python features that can be disabled by removing them
            // from this list.   If this item is omited, all features are enabled
            StatementWhiteList = new List<string> { "def", "class", "return", "del", "for", "async for",
                "while", "if", "with", "async with", "raise", "try", "assert", "import", "import from", 
                "global", "nonlocal", "pass", "break", "continue", "lambda", "setcomp", "listcomp",
                "dictcomp", "generatorexp", "ifexp", "attribute", "match", "slice" },
        };

        string src = @"
x = 2
a = search_email(x)
if (a < 3):
    y = search_email(a + 5)
else:
    y = search_email(a + 10)
return y
";



        var client = new ApiConductorClient(config, typeof(MyConversation));

        await client.ConnectAsync();

        var conversation = new MyConversation(client, src);
        await conversation.Wait();

        await client.CloseAsync();
    }
}


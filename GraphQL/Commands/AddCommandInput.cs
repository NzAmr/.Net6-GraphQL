namespace CommanderGQL.GraphQL.Commands
{
    public record AddCommandInput(string HowTo, string CommandLine , int PlatformId);
    public record ModifyCommandInput(int Id,string HowTo, string CommandLine , int PlatformId);
}
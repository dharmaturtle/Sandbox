namespace MyTypes

[<CLIMutable>]
type Parameters = {
    item : string
}

[<CLIMutable>]
type QueryResult = {
    action : string
    parameters : Parameters
}

[<CLIMutable>]
type Root = {
    queryResult : QueryResult
}

module Tests

open System
open Xunit
open Sandbox

let d x =
    x.D() |> ignore
    x
let di x =
    x.Di()

[<Fact>]
let ``T1`` () =
    "Hello world".Di()
    "Hello world" |> di

[<Theory>]
[<InlineData("a", "b")>]
let ``T2`` (a: string) (b:string) =
    a.Di()
    b.Di()

let ``T2.5 values`` : obj[] seq = seq {
    yield [| 3 ;  4 |] 
    yield [| 32; 42 |]
} [<Theory; MemberData(nameof ``T2.5 values``)>]
let ``T2.5`` (a:int, b) =
    Assert.NotEqual(a, b)

let ``T3 values`` : obj[] seq = seq {
    yield [|  [|1; 2|]
              "a"      |] 
    yield [|  [|3; 4|]
              "b"      |]
} [<Theory; MemberData(nameof ``T3 values``)>]
let ``T3`` (xs, y) =
    for x in xs do
        x.Di()
    y.Di()

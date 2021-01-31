module HedgehogTests

open System
open Xunit
open Tests
open Sandbox
open Hedgehog
open Hedgehog.Xunit

[<Property>]
let ``Reversing a list twice yields the original list, with Hedgehog.Xunit`` (xs: int list) =
    List.rev (List.rev xs) = xs


type Int13 =
    static member __ =
        GenX.defaults
        |> AutoGenConfig.addGenerator (Gen.constant 13)

type PropertyInt13Attribute() = inherit PropertyAttribute(typeof<Int13>)

[<PropertyInt13>]
let ``this passes`` (i: int) =
    i = 13

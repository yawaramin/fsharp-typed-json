namespace TypedJson.Core.Test

open TypedJson.Core
open Xunit
open To_json.Ops

module To_json_test =
  [<Fact>]
  let int () =
    Assert.Equal("1", to_json To_json.int 1)

  [<Fact>]
  let string () =
    Assert.Equal("\"1\"", to_json To_json.string "1")

  [<Fact>]
  let float () =
    Assert.Equal("1.0", to_json To_json.float 1.0)

  [<Fact>]
  let double () =
    Assert.Equal("1.0", to_json To_json.double 1.0)

  [<Fact>]
  let char () =
    Assert.Equal("\"1\"", to_json To_json.char '1')

  [<Fact>]
  let bool () =
    Assert.Equal("false", to_json To_json.bool false)
    Assert.Equal("true", to_json To_json.bool true)

  [<Fact>]
  let option () =
    let option_int = To_json.option To_json.int

    Assert.Equal("null", to_json option_int None)
    Assert.Equal("1", to_json option_int <| Some 1)

  [<Fact>]
  let array () =
    let array_int = To_json.array To_json.int

    Assert.Equal("[]", to_json array_int Array.empty)
    Assert.Equal("[1]", to_json array_int [| 1 |])
    Assert.Equal("[1,2]", to_json array_int [| 1; 2 |])

  [<Fact>]
  let object2 () =
    let person = Person.mk "bob" <| Some 31
    let json = """{"name":"bob","age":31}"""

    Assert.Equal(json, to_json Person.to_json person)

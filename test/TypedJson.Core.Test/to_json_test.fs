namespace TypedJson.Core.Test

open TypedJson.Core
open Xunit
open To_json.Ops

module To_json_test =
  type t() =
    let t2 = ("bob", None)
    let t3 = (1, true, "false")
    let t4 = (1, true, "false", 5.55)
    let t5 = (1, true, "false", 5.55, 'c')
    let t6 = (1, true, "false", 5.55, 'c', [|1|])
    let t7 = (1, true, "false", 5.55, 'c', [|1|], 3.14159)
    let t8 = (1, true, "false", 5.55, 'c', [|1|], 3.14159, (1, true))

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

    [<Fact>]
    let tuple2 () =
      let json = """["bob",null]"""

      Assert.Equal(
        json,
        to_json
          (To_json.tuple2 To_json.string <| To_json.option To_json.int)
          t2)

    [<Fact>]
    let tuple3 () =
      let json = """[1,true,"false"]"""

      Assert.Equal(
        json,
        to_json
          (To_json.tuple3 To_json.int To_json.bool To_json.string) t3)

    [<Fact>]
    let tuple4 () =
      let json = """[1,true,"false",5.55]"""

      Assert.Equal(
        json,
        to_json
          (To_json.tuple4
            To_json.int To_json.bool To_json.string To_json.float) t4)

    [<Fact>]
    let tuple5 () =
      let json = """[1,true,"false",5.55,"c"]"""

      Assert.Equal(
        json,
        to_json
          (To_json.tuple5
            To_json.int
            To_json.bool
            To_json.string
            To_json.float
            To_json.char)

          t5)

    [<Fact>]
    let tuple6 () =
      let json = """[1,true,"false",5.55,"c",[1]]"""

      Assert.Equal(
        json,
        to_json
          (To_json.tuple6
            To_json.int
            To_json.bool
            To_json.string
            To_json.float
            To_json.char
            (To_json.array To_json.int))

          t6)

    [<Fact>]
    let tuple7 () =
      let json = """[1,true,"false",5.55,"c",[1],3.14159]"""

      Assert.Equal(
        json,
        to_json
          (To_json.tuple7
            To_json.int
            To_json.bool
            To_json.string
            To_json.float
            To_json.char
            (To_json.array To_json.int)
            To_json.double)

          t7)

    [<Fact>]
    let tuple8 () =
      let json = """[1,true,"false",5.55,"c",[1],3.14159,[1,true]]"""

      Assert.Equal(
        json,
        to_json
          (To_json.tuple8
            To_json.int
            To_json.bool
            To_json.string
            To_json.float
            To_json.char
            (To_json.array To_json.int)
            To_json.double
            (To_json.tuple2 To_json.int To_json.bool))

          t8)

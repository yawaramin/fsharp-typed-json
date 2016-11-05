namespace TypedJson.Core.Test

open TypedJson.Core
open Key_value.Ops
open To_json.Ops

module Person =
  type t = { name : string; age : option<int> }

  let mk name age = { name = name; age = age }
  let name person = person.name
  let age person = person.age

  (** A person to JSON converter. *)
  let to_json =
    To_json.object2
      (key "name" << name, To_json.string)
      (key "age" << age, To_json.option To_json.int)

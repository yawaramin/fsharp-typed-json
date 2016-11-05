namespace TypedJson.Core

open System.Collections.Generic

[<RequireQualifiedAccess>]
module Key_value =
  type 'a t = (string, 'a) KeyValuePair

  let get_key (t:'a t) = t.Key
  let get_value (t:'a t) = t.Value

  module Ops = let key (name:string) value = KeyValuePair(name, value)

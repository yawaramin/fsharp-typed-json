namespace TypedJson.Core

(** Type and operations for a value labelled by a string. *)
module Key_value =
  type 'a t = (string, 'a) System.Collections.Generic.KeyValuePair

  val get_key : 'a t -> string
  val get_value : 'a t -> 'a

  module Ops =
    (**
    Returns a key-value pair of the given name and value. This is a
    helper function to make creating JSON instances easier.
    *)
    val key : string -> 'a -> 'a t

namespace TypedJson.Core

(**
The 'a To_json.t typeclass, instances for primitive types, and instance
builders for arbitrary (product) data types.
*)
module To_json =
  (**
  Essentially this is just a wrapper for a function which can convert a
  given type 'a to a JSON string. A good way to think of it is also as a
  proposition that a type 'a can be converted into a JSON string. The
  typeclass instances of the various types are proofs that those types
  can be converted into JSON strings.
  *)
  type 'a t

  (* JSON converter instances for primitive types. *)

  val unit : unit t
  val int : int t
  val string : string t
  val float : float t
  val double : double t
  val char : char t
  val bool : bool t
  val option : 'a t -> 'a option t
  val array : 'a t -> 'a array t

  (*
  The following are used to create JSON converter instances that
  construct valid JSON objects out of at least one key-value pair. They
  work by extracting (or converting) the input value (of type 'a) into
  one or more output values which we already know can be converted. This
  way we can convert recursively into an arbitrary depth.

  In F# terminology, these functions encode record types.
  *)

  val object1 : ('a -> 'b1 Key_value.t) * 'b1 t -> 'a t
  val object2 :
    ('a -> 'b1 Key_value.t) * 'b1 t ->
    ('a -> 'b2 Key_value.t) * 'b2 t ->
    'a t

  val object3 :
    ('a -> 'b1 Key_value.t) * 'b1 t ->
    ('a -> 'b2 Key_value.t) * 'b2 t ->
    ('a -> 'b3 Key_value.t) * 'b3 t ->
    'a t

  val object4 :
    ('a -> 'b1 Key_value.t) * 'b1 t ->
    ('a -> 'b2 Key_value.t) * 'b2 t ->
    ('a -> 'b3 Key_value.t) * 'b3 t ->
    ('a -> 'b4 Key_value.t) * 'b4 t ->
    'a t

  val object5 :
    ('a -> 'b1 Key_value.t) * 'b1 t ->
    ('a -> 'b2 Key_value.t) * 'b2 t ->
    ('a -> 'b3 Key_value.t) * 'b3 t ->
    ('a -> 'b4 Key_value.t) * 'b4 t ->
    ('a -> 'b5 Key_value.t) * 'b5 t ->
    'a t

  val object6 :
    ('a -> 'b1 Key_value.t) * 'b1 t ->
    ('a -> 'b2 Key_value.t) * 'b2 t ->
    ('a -> 'b3 Key_value.t) * 'b3 t ->
    ('a -> 'b4 Key_value.t) * 'b4 t ->
    ('a -> 'b5 Key_value.t) * 'b5 t ->
    ('a -> 'b6 Key_value.t) * 'b6 t ->
    'a t

  val object7 :
    ('a -> 'b1 Key_value.t) * 'b1 t ->
    ('a -> 'b2 Key_value.t) * 'b2 t ->
    ('a -> 'b3 Key_value.t) * 'b3 t ->
    ('a -> 'b4 Key_value.t) * 'b4 t ->
    ('a -> 'b5 Key_value.t) * 'b5 t ->
    ('a -> 'b6 Key_value.t) * 'b6 t ->
    ('a -> 'b7 Key_value.t) * 'b7 t ->
    'a t

  val object8 :
    ('a -> 'b1 Key_value.t) * 'b1 t ->
    ('a -> 'b2 Key_value.t) * 'b2 t ->
    ('a -> 'b3 Key_value.t) * 'b3 t ->
    ('a -> 'b4 Key_value.t) * 'b4 t ->
    ('a -> 'b5 Key_value.t) * 'b5 t ->
    ('a -> 'b6 Key_value.t) * 'b6 t ->
    ('a -> 'b7 Key_value.t) * 'b7 t ->
    ('a -> 'b8 Key_value.t) * 'b8 t ->
    'a t

  (* Instances to encode tuples as JSON heterogeneous arrays. *)

  val tuple2 : 'a1 t -> 'a2 t -> ('a1 * 'a2) t
  val tuple3 : 'a1 t -> 'a2 t -> 'a3 t -> ('a1 * 'a2 * 'a3) t
  val tuple4 :
    'a1 t -> 'a2 t -> 'a3 t -> 'a4 t -> ('a1 * 'a2 * 'a3 * 'a4) t

  val tuple5 :
    'a1 t ->
    'a2 t ->
    'a3 t ->
    'a4 t ->
    'a5 t ->
    ('a1 * 'a2 * 'a3 * 'a4 * 'a5) t

  val tuple6 :
    'a1 t ->
    'a2 t ->
    'a3 t ->
    'a4 t ->
    'a5 t ->
    'a6 t ->
    ('a1 * 'a2 * 'a3 * 'a4 * 'a5 * 'a6) t

  val tuple7 :
    'a1 t ->
    'a2 t ->
    'a3 t ->
    'a4 t ->
    'a5 t ->
    'a6 t ->
    'a7 t ->
    ('a1 * 'a2 * 'a3 * 'a4 * 'a5 * 'a6 * 'a7) t

  val tuple8 :
    'a1 t ->
    'a2 t ->
    'a3 t ->
    'a4 t ->
    'a5 t ->
    'a6 t ->
    'a7 t ->
    'a8 t ->
    ('a1 * 'a2 * 'a3 * 'a4 * 'a5 * 'a6 * 'a7 * 'a8) t

  (*
  Instances to encode sum types as JSON objects. They work by testing
  the input against each case of the sum type and encoding to the first
  type that matches. The flaw in this method is that if the sum type has
  two cases which have identical types, only the first case will be
  matched.
  *)

  val sum2 :
    ('a -> 'b1 Key_value.t) * 'b1 t ->
    ('a -> 'b2 Key_value.t) * 'b2 t ->
    'a t

  val sum3 :
    ('a -> 'b1 Key_value.t) * 'b1 t ->
    ('a -> 'b2 Key_value.t) * 'b2 t ->
    ('a -> 'b3 Key_value.t) * 'b3 t ->
    'a t

  val sum4 :
    ('a -> 'b1 Key_value.t) * 'b1 t ->
    ('a -> 'b2 Key_value.t) * 'b2 t ->
    ('a -> 'b3 Key_value.t) * 'b3 t ->
    ('a -> 'b4 Key_value.t) * 'b4 t ->
    'a t

  val sum5 :
    ('a -> 'b1 Key_value.t) * 'b1 t ->
    ('a -> 'b2 Key_value.t) * 'b2 t ->
    ('a -> 'b3 Key_value.t) * 'b3 t ->
    ('a -> 'b4 Key_value.t) * 'b4 t ->
    ('a -> 'b5 Key_value.t) * 'b5 t ->
    'a t

  val sum6 :
    ('a -> 'b1 Key_value.t) * 'b1 t ->
    ('a -> 'b2 Key_value.t) * 'b2 t ->
    ('a -> 'b3 Key_value.t) * 'b3 t ->
    ('a -> 'b4 Key_value.t) * 'b4 t ->
    ('a -> 'b5 Key_value.t) * 'b5 t ->
    ('a -> 'b6 Key_value.t) * 'b6 t ->
    'a t

  val sum7 :
    ('a -> 'b1 Key_value.t) * 'b1 t ->
    ('a -> 'b2 Key_value.t) * 'b2 t ->
    ('a -> 'b3 Key_value.t) * 'b3 t ->
    ('a -> 'b4 Key_value.t) * 'b4 t ->
    ('a -> 'b5 Key_value.t) * 'b5 t ->
    ('a -> 'b6 Key_value.t) * 'b6 t ->
    ('a -> 'b7 Key_value.t) * 'b7 t ->
    'a t

  val sum8 :
    ('a -> 'b1 Key_value.t) * 'b1 t ->
    ('a -> 'b2 Key_value.t) * 'b2 t ->
    ('a -> 'b3 Key_value.t) * 'b3 t ->
    ('a -> 'b4 Key_value.t) * 'b4 t ->
    ('a -> 'b5 Key_value.t) * 'b5 t ->
    ('a -> 'b6 Key_value.t) * 'b6 t ->
    ('a -> 'b7 Key_value.t) * 'b7 t ->
    ('a -> 'b8 Key_value.t) * 'b8 t ->
    'a t

  (** Operations meant to be imported directly into client code. *)
  module Ops =
    (**
    Returns a JSON converter function from some type 'a to a string.
    *)
    val to_json : 'a t -> ('a -> string)

    (**
    Returns a JSON converter instance for an arbitrary type 'a given a
    function that can convert an 'a value into a JSON string.
    *)
    val make_to_json : ('a -> string) -> 'a t

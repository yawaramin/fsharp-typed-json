namespace TypedJson.Core

module Try =
  type 'a t

  val apply : (unit -> 'a) -> 'a t
  val map : ('a -> 'b) -> 'a t -> 'b t

  (**
  Returns the wrapped value if the given `Try.t` value is a `Success`,
  else returns a default value of the same time after calling the given
  value producer function.
  *)
  val get_or_else : (unit -> 'a) -> 'a t -> 'a

  (**
  Returns the first `Try.t` if it's successful; otherwise the second
  one.
  *)
  val or_else : 'a t -> 'a t -> 'a t
  val sequence : 'a t array -> 'a t

  module Ops =
    val try' : ((unit -> 'a) -> 'a t)
    val succeed : 'a -> 'a t
    val fail : exn -> 'a t

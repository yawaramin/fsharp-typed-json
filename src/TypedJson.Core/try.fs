namespace TypedJson.Core

[<RequireQualifiedAccess>]
module Try =
  type 'a t = Success of 'a | Failure of exn

  let apply lazy_a = try () |> lazy_a |> Success with exn -> Failure exn
  let map f = function
    | Success a -> apply <| fun () -> f a
    | Failure exn -> Failure exn

  let get_or_else default_a = function
    | Success a -> a
    | Failure _ -> default_a ()

  let or_else t1 t2 = match t1 with Success _ -> t1 | _ -> t2
  let sequence ts = Array.reduce or_else ts

  module Ops =
    let try' = apply
    let succeed = Success
    let fail = Failure

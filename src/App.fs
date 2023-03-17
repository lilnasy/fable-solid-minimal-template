module TodoElmish

open Fable.Core
open Feliz.JSX.Solid
open Elmish.Solid

printfn $"Loading {__SOURCE_FILE__}..."

type Model = { count: int }

type Message = Increment | Decrement

let init () = { count = 0 }, Elmish.Cmd.none

let update msg model =
    match msg with
    | Increment -> { model with count = model.count + 1 }, Elmish.Cmd.none
    | Decrement -> { model with count = model.count - 1 }, Elmish.Cmd.none

[<JSX.Component>]
let Counter =
    let model, dispatch = Solid.createElmishStore (init, update)

    Html.div [
        Html.h1 "Hello world!"

        Html.div [
            Html.p $"{model.count}"
        ]
        
        Html.div [
            Html.button [
                Ev.onClick (fun _ -> dispatch Increment)
                Html.children [ Html.text "(+)" ]
            ]
        ]
        
        Html.div [
            Html.button [
                Ev.onClick (fun _ -> dispatch Decrement)
                Html.children [ Html.text "(-)" ]
            ]
        ]
    ]

let app () = Counter
let target = Browser.Dom.document.getElementById("solid-app")
Solid.render(app, target)

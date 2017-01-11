namespace GoogleAppsScript
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

[<AutoOpen>]
    module Optimization =
        type [<AllowNullLiteral>] LinearOptimizationConstraint =
            abstract setCoefficient: variableName: string * coefficient: float -> LinearOptimizationConstraint

        and [<AllowNullLiteral>] LinearOptimizationEngine =
            abstract addConstraint: lowerBound: float * upperBound: float -> LinearOptimizationConstraint
            abstract addVariable: name: string * lowerBound: float * upperBound: float -> LinearOptimizationEngine
            abstract addVariable: name: string * lowerBound: float * upperBound: float * ``type``: VariableType -> LinearOptimizationEngine
            abstract setMaximization: unit -> LinearOptimizationEngine
            abstract setMinimization: unit -> LinearOptimizationEngine
            abstract setObjectiveCoefficient: variableName: string * coefficient: float -> LinearOptimizationEngine
            abstract solve: unit -> LinearOptimizationSolution
            abstract solve: seconds: float -> LinearOptimizationSolution

        and [<AllowNullLiteral>] LinearOptimizationService =
            abstract Status: Status with get, set
            abstract VariableType: VariableType with get, set
            abstract createEngine: unit -> LinearOptimizationEngine

        and [<AllowNullLiteral>] LinearOptimizationSolution =
            abstract getObjectiveValue: unit -> float
            abstract getStatus: unit -> Status
            abstract getVariableValue: variableName: string -> float
            abstract isValid: unit -> bool

        and Status =
            | OPTIMAL = 0
            | FEASIBLE = 1
            | INFEASIBLE = 2
            | UNBOUNDED = 3
            | ABNORMAL = 4
            | MODEL_INVALID = 5
            | NOT_SOLVED = 6

        and VariableType =
            | INTEGER = 0
            | CONTINUOUS = 1

//type [<Erase>]Globals =
//    [<Global>] static member LinearOptimizationService with get(): GoogleAppsScript.Optimization.LinearOptimizationService = jsNative and set(v: GoogleAppsScript.Optimization.LinearOptimizationService): unit = jsNative



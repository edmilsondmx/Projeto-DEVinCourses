import { ITraining } from "./training";

export interface IRegistration{
    id: number | undefined;
    userId: number | undefined;
    trainingId: number | undefined;
    status : number | undefined;
    training: ITraining | undefined;
}
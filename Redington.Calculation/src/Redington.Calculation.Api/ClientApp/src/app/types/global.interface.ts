export interface CalculationResult {
  result: number;
  date: string;
  typeOfCalculation: string;
  inputs: Probability[];
  longitude: string;
}

export interface Probability {
  value: number;
}

export interface CalculationRequest {
  A: number;
  B: number;
}

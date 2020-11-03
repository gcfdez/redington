import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CalculationResult, CalculationRequest } from 'src/app/types/global.interface';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  @Output() isValid = new EventEmitter<boolean>();
  baseUrl: string;
  calculationForm: FormGroup;
  calculationResult: any;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.calculationResult = 0.0;

    this.calculationForm = new FormGroup({
      probabilityA: new FormControl('', [
        Validators.required,
        Validators.maxLength(4),
        Validators.min(0),
        Validators.max(1)
      ]),
      probabilityB: new FormControl('', [
        Validators.required,
        Validators.maxLength(4),
        Validators.min(0),
        Validators.max(1)
      ]),
      typeOfCalculation: new FormControl('', [
        Validators.required
      ])
    }, { updateOn: 'blur' });
  }

  GetHeaders() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
  }

  /**
   * @description Attempt to submit the calculationForm form. If the form is valid, then push the probabilities
   * to the function selected and emit true. If invalid, set all form elements to dirty which will
   * present any error messages.
   * @return boolean
   */
  public onSubmit() {
    if (this.calculationForm.valid) {
      const calculationRequest: CalculationRequest = {
        A: this.calculationForm.controls.probabilityA.value,
        B: this.calculationForm.controls.probabilityB.value
      };

      const typeOfCalculation: string = this.calculationForm.controls.typeOfCalculation.value;

      this.httpClient.post<CalculationResult>(this.baseUrl + 'api/calculation/' + typeOfCalculation,
        calculationRequest,
        this.GetHeaders())
        .subscribe(response => {
          this.calculationResult = response.result
        }, error => console.log(error))

      this.isValid.emit(true);
      return true;
    } else {
      // The form has attempted to be submitted, but the form contains
      // at least one invalid field input. Go through each form control
      // and if it contains an invalid input, mark it as dirty.
      this.isValid.emit(false);
      Object.keys(this.calculationForm.controls).forEach(key => {
        this.calculationForm.controls[key].markAsDirty();
      });
      return false;
    }
  }
}

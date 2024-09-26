import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";
// Need to use a custom validator instead of maxLength and minLength since control.value is a number here
export function checkIsNumber(): ValidatorFn {
    return (control: AbstractControl) : ValidationErrors | null => {
        const value = control.value;
        if (!value) {
            return null;
        }
        if (!isNumeric(value)) {
            return {notANumber: true}
        }
        return null;
    }
}

function isNumeric(str: string): boolean {
    return str.split('').every(char => !isNaN(Number(char)));
  }
import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";
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
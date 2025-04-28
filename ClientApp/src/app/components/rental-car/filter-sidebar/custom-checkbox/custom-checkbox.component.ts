import { Component, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-custom-checkbox',
  templateUrl: './custom-checkbox.component.html',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CustomCheckboxComponent),
      multi: true,
    },
  ],
})
export class CustomCheckboxComponent implements ControlValueAccessor {
  @Input() id!: string;
  @Input() filterProperty!: 'carType' | 'carBrand';
  @Input() name!: string;

  value: boolean = false;
  disabled: boolean = false;

  private onChange: (value: any) => void = () => {};
  private onTouched: () => void = () => {};

  writeValue(obj: {
    id: string;
    filterProperty: 'carType' | 'carBrand';
    value: boolean;
  }): void {
    if (obj) {
      this.id = obj.id || this.id;
      this.filterProperty = obj.filterProperty || this.filterProperty;
      this.value = obj.value || false;
    }
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState?(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }

  onCheckboxChange(event: Event): void {
    const checked = (event.target as HTMLInputElement).checked;
    this.value = checked;
    this.onChange({
      id: this.id,
      filterProperty: this.filterProperty,
      value: this.value,
    });
    this.onTouched();
  }
}

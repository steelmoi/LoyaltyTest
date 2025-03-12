import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-content-wrapper',
  templateUrl: './content-wrapper.component.html',
  styleUrl: './content-wrapper.component.css'
})
export class ContentWrapperComponent {
  @Input() Title: string = ""
  @Input() Item: string = ""
  @Input() SubItem: string = ""

  CanDisplay: boolean = true

  ngOnInit(): void {
    this.CanDisplay = (this.Item != "" && this.SubItem != "")
  }
}

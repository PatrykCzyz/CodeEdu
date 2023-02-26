import { Component, Input, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { CourseDto, CoursesClient } from 'src/app/api/client';

@Component({
  selector: 'app-courses-list',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.scss'],
})
export class CoursesListComponent implements OnInit {
  @Input()
  public refreshSubject?: Subject<void>;

  public courses: CourseDto[] = [];

  public getDescription(course: CourseDto) {
    if (!course.description) return '';

    if (course.description.length <= 258) return course.description;

    return course.description.substring(0, 255) + '...';
  }

  constructor(private _coursesClient: CoursesClient) {}

  ngOnInit(): void {
    this._getCourses();
    this.refreshSubject?.subscribe(() => this._getCourses());
  }

  identify(index: number, course: CourseDto) {
    return course.id;
  }


  private _getCourses() {
    this._coursesClient.getCourses().subscribe((res) => {
      this.courses = res.sort((a, b) => b.createdAt!.getTime() - a.createdAt!.getTime());
    });
  }
}

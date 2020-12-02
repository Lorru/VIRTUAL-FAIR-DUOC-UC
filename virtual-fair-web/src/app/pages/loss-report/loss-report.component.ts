import { Component, OnInit } from "@angular/core";
import { DatePipe } from "@angular/common";
import { SummaryReportService } from "app/services/summary-report.service";

@Component({
  selector: "app-loss-report",
  templateUrl: "./loss-report.component.html",
  styleUrls: ["./loss-report.component.css"],
  providers: [DatePipe],
})
export class LossReportComponent implements OnInit {
  dateFrom: any;
  dateTo: any;

  summaryReport: any;
  fruitLossReports: Array<any> = [];

  hasSearched: boolean;

  constructor(public _summaryReportService: SummaryReportService) {
    const date = new Date();
    const firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
    const lastDay = new Date(date.getFullYear(), date.getMonth() + 1, 0);
    this.dateTo = lastDay.toISOString().substr(0, 10);
    this.dateFrom = firstDay.toISOString().substr(0, 10);
    this.getLossReport();
  }

  ngOnInit() {}

  getLossReport() {
    const dateFrom = new Date(this.dateFrom).toISOString().substr(0, 10);
    const dateTo = new Date(this.dateTo).toISOString().substr(0, 10);
    this._summaryReportService
      .findByIdPurchaseRequestStatusInTwoNineAndUpdateDate(dateFrom, dateTo)
      .subscribe((res: any) => {
        console.log("reports", res);
        this.hasSearched = true;
        if (res.statusCode === 200) {
          this.summaryReport = res.summaryReport;
          this.fruitLossReports = res.summaryReport.detailReports;
        }
      });
  }

  downloadLossReport() {
    const dateFrom = new Date(this.dateFrom).toISOString().substr(0, 10);
    const dateTo = new Date(this.dateTo).toISOString().substr(0, 10);
    this._summaryReportService
      .findByIdPurchaseRequestStatusInTwoNineAndUpdateDatePdf(dateFrom, dateTo)
      .subscribe((res: any) => {
        console.log("reports", res);
        // this.urltoFile(`data:application/pdf;base64,${res.file}`, res.fileName,'application/pdf')
        // .then(function(file){ console.log(file);});

        const downloadLink = document.createElement("a");

        downloadLink.href = `data:application/pdf;base64,${res.file}`;
        downloadLink.download = res.fileName;
        downloadLink.click();
      });
  }

  urltoFile(url, filename, mimeType) {
    return fetch(url)
      .then(function (res) {
        return res.arrayBuffer();
      })
      .then(function (buf) {
        return new File([buf], filename, { type: mimeType });
      });
  }
}

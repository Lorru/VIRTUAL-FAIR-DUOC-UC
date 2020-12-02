package cl.virtualfair.services.other;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Map.Entry;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.amazonaws.util.Base64;
import com.itextpdf.text.Chunk;
import com.itextpdf.text.Document;
import com.itextpdf.text.DocumentException;
import com.itextpdf.text.Element;
import com.itextpdf.text.Font;
import com.itextpdf.text.FontFactory;
import com.itextpdf.text.Phrase;
import com.itextpdf.text.pdf.PdfPCell;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;

import cl.virtualfair.models.other.DetailReport;
import cl.virtualfair.models.other.SummaryReport;

@Service
public class SummaryReportService {

	@Autowired
	private DetailReportService detailReportService;
	
	public SummaryReportService() {
		
	}
	
	public SummaryReport findByIdPurchaseRequestStatusInTwoNineAndUpdateDate(String updateDateOf, String updateDateTo) {
		
		SummaryReport summaryReport = null;
		
		List<DetailReport> detailReports = detailReportService.findByIdPurchaseRequestStatusInTwoNineAndUpdateDate(updateDateOf, updateDateTo);
		
		if(detailReports.size() > 0) {
			
			String mostLostProduct = detailReports.stream().map(x -> x.getProduct()).collect(Collectors.groupingBy(x -> x, Collectors.counting())).entrySet().stream().max(Comparator.comparing(Entry::getValue)).get().getKey();
			long totalCostLoss = detailReports.stream().mapToLong(x -> x.getCostLoss()).sum();
			double totalWeightLoss = detailReports.stream().mapToDouble(x -> x.getWeight()).sum();;
			
			summaryReport = new SummaryReport();
			
			summaryReport.setDetailReports(detailReports);
			summaryReport.setMostLostProduct(mostLostProduct);
			summaryReport.setTotalCostLoss(totalCostLoss);
			summaryReport.setTotalWeightLoss(totalWeightLoss);
		}
		
		return summaryReport;
	}
	
	public String findByIdPurchaseRequestStatusInTwoNineAndUpdateDatePdf(String updateDateOf, String updateDateTo) throws DocumentException, IOException {
		
		SummaryReport summaryReport = findByIdPurchaseRequestStatusInTwoNineAndUpdateDate(updateDateOf, updateDateTo);
		
		String file = null;
		
		if(summaryReport != null) {
		
			Document document = new Document();
			
			ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
			
			PdfPTable pdfPTableDetailReport = new PdfPTable(6);
			
			List<String> headers = new ArrayList<String>();
			
			headers.add("ID proceso venta");
			headers.add("Producto");
			headers.add("Peso Kg");
			headers.add("Solicitante");
			headers.add("Fecha");
			headers.add("Costo pérdida");
			
			Font font = FontFactory.getFont(FontFactory.HELVETICA_BOLD);
			
			for (String header : headers) {
			
		        PdfPCell pdfPCellHeader = new PdfPCell(new Phrase(header, font));
		        pdfPCellHeader.setBorderWidth(2);
		        pdfPCellHeader.setHorizontalAlignment(Element.ALIGN_CENTER);
		        
		        pdfPTableDetailReport.addCell(pdfPCellHeader);
				
			}

			for (DetailReport detailReport : summaryReport.getDetailReports()) {
				
		        PdfPCell pdfPCellIdPurchaseRequest = new PdfPCell(new Phrase(detailReport.getIdPurchaseRequest()));
		        pdfPCellIdPurchaseRequest.setBorderWidth(2);
		        pdfPCellIdPurchaseRequest.setVerticalAlignment(Element.ALIGN_MIDDLE);
		        pdfPCellIdPurchaseRequest.setHorizontalAlignment(Element.ALIGN_CENTER);
		        pdfPTableDetailReport.addCell(pdfPCellIdPurchaseRequest);
		        
		        PdfPCell pdfPCellProduct = new PdfPCell(new Phrase(detailReport.getProduct()));
		        pdfPCellProduct.setBorderWidth(2);
		        pdfPCellProduct.setVerticalAlignment(Element.ALIGN_MIDDLE);
		        pdfPCellProduct.setHorizontalAlignment(Element.ALIGN_CENTER);
		        pdfPTableDetailReport.addCell(pdfPCellProduct);
		        
		        PdfPCell pdfPCellWeight = new PdfPCell(new Phrase(String.valueOf(detailReport.getWeight())));
		        pdfPCellWeight.setBorderWidth(2);
		        pdfPCellWeight.setVerticalAlignment(Element.ALIGN_MIDDLE);
		        pdfPCellWeight.setHorizontalAlignment(Element.ALIGN_CENTER);
		        pdfPTableDetailReport.addCell(pdfPCellWeight);
		        
		        PdfPCell pdfPCellClient = new PdfPCell(new Phrase(detailReport.getClient()));
		        pdfPCellClient.setBorderWidth(2);
		        pdfPCellClient.setVerticalAlignment(Element.ALIGN_MIDDLE);
		        pdfPCellClient.setHorizontalAlignment(Element.ALIGN_CENTER);
		        pdfPTableDetailReport.addCell(pdfPCellClient);
		        
		        PdfPCell pdfPCellDate = new PdfPCell(new Phrase(detailReport.getDate().format(DateTimeFormatter.ofPattern("yyyy-MM-dd")).toString()));
		        pdfPCellDate.setBorderWidth(2);
		        pdfPCellDate.setVerticalAlignment(Element.ALIGN_MIDDLE);
		        pdfPCellDate.setHorizontalAlignment(Element.ALIGN_CENTER);
		        pdfPTableDetailReport.addCell(pdfPCellDate);
		        
		        PdfPCell pdfPCellCostLoss = new PdfPCell(new Phrase(detailReport.getCostLoss()));
		        pdfPCellCostLoss.setBorderWidth(2);
		        pdfPCellCostLoss.setVerticalAlignment(Element.ALIGN_MIDDLE);
		        pdfPCellCostLoss.setHorizontalAlignment(Element.ALIGN_CENTER);
		        pdfPTableDetailReport.addCell(pdfPCellCostLoss);
		       
			}
			
			Chunk chunkSpace = new Chunk("\r");
			
			Chunk chunkTitle = new Chunk("Resumen reporte");
			
			PdfPTable pdfPTableSummaryReport = new PdfPTable(2);
			
	        PdfPCell pdfPCellHeaderTotalCostLoss = new PdfPCell(new Phrase("Costo total pérdida"));
	        pdfPCellHeaderTotalCostLoss.setBorderWidth(2);
	        pdfPCellHeaderTotalCostLoss.setVerticalAlignment(Element.ALIGN_MIDDLE);
	        pdfPCellHeaderTotalCostLoss.setHorizontalAlignment(Element.ALIGN_CENTER);
	        pdfPTableSummaryReport.addCell(pdfPCellHeaderTotalCostLoss);
	        
	        PdfPCell pdfPCellTotalCostLoss = new PdfPCell(new Phrase(summaryReport.getTotalCostLoss()));
	        pdfPCellTotalCostLoss.setBorderWidth(2);
	        pdfPCellTotalCostLoss.setVerticalAlignment(Element.ALIGN_MIDDLE);
	        pdfPCellTotalCostLoss.setHorizontalAlignment(Element.ALIGN_CENTER);
	        pdfPTableSummaryReport.addCell(pdfPCellTotalCostLoss);
	        
	        PdfPCell pdfPCellHeaderTotalWeightLoss = new PdfPCell(new Phrase("Peso total pérdida"));
	        pdfPCellHeaderTotalWeightLoss.setBorderWidth(2);
	        pdfPCellHeaderTotalWeightLoss.setVerticalAlignment(Element.ALIGN_MIDDLE);
	        pdfPCellHeaderTotalWeightLoss.setHorizontalAlignment(Element.ALIGN_CENTER);
	        pdfPTableSummaryReport.addCell(pdfPCellHeaderTotalWeightLoss);
	        
	        PdfPCell pdfPCellTotalWeightLoss = new PdfPCell(new Phrase(String.valueOf(summaryReport.getTotalWeightLoss())));
	        pdfPCellTotalWeightLoss.setBorderWidth(2);
	        pdfPCellTotalWeightLoss.setVerticalAlignment(Element.ALIGN_MIDDLE);
	        pdfPCellTotalWeightLoss.setHorizontalAlignment(Element.ALIGN_CENTER);
	        pdfPTableSummaryReport.addCell(pdfPCellTotalWeightLoss);
	        
	        PdfPCell pdfPCellHeaderMostLostProduct = new PdfPCell(new Phrase("Producto más perdido"));
	        pdfPCellHeaderMostLostProduct.setBorderWidth(2);
	        pdfPCellHeaderMostLostProduct.setVerticalAlignment(Element.ALIGN_MIDDLE);
	        pdfPCellHeaderMostLostProduct.setHorizontalAlignment(Element.ALIGN_CENTER);
	        pdfPTableSummaryReport.addCell(pdfPCellHeaderMostLostProduct);
	        
	        PdfPCell pdfPCellMostLostProduct = new PdfPCell(new Phrase(summaryReport.getMostLostProduct()));
	        pdfPCellMostLostProduct.setBorderWidth(2);
	        pdfPCellMostLostProduct.setVerticalAlignment(Element.ALIGN_MIDDLE);
	        pdfPCellMostLostProduct.setHorizontalAlignment(Element.ALIGN_CENTER);
	        pdfPTableSummaryReport.addCell(pdfPCellMostLostProduct);
			
	        PdfWriter.getInstance(document, byteArrayOutputStream);
	        
	        document.open();
	        
	        document.add(pdfPTableDetailReport);
	        document.add(chunkSpace);
	        document.add(chunkTitle);
	        document.add(pdfPTableSummaryReport);
	        
	        document.close();
	        
	        file = Base64.encodeAsString(byteArrayOutputStream.toByteArray());
	        
	        byteArrayOutputStream.close();
			
		}
		
		return file;
	}
}

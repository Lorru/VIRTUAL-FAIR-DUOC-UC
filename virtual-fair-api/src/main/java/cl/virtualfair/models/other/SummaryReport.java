package cl.virtualfair.models.other;

import java.util.List;

public class SummaryReport {

	private long TotalCostLoss;
	
	private double TotalWeightLoss;
	
	private String MostLostProduct;
	
	private List<DetailReport> DetailReports;
	
	public SummaryReport() {
		
	}
	

	public SummaryReport(long totalCostLoss, double totalWeightLoss, String mostLostProduct,
			List<DetailReport> detailReports) {
		TotalCostLoss = totalCostLoss;
		TotalWeightLoss = totalWeightLoss;
		MostLostProduct = mostLostProduct;
		DetailReports = detailReports;
	}


	public long getTotalCostLoss() {
		return TotalCostLoss;
	}

	public void setTotalCostLoss(long totalCostLoss) {
		TotalCostLoss = totalCostLoss;
	}

	public double getTotalWeightLoss() {
		return TotalWeightLoss;
	}

	public void setTotalWeightLoss(double totalWeightLoss) {
		TotalWeightLoss = totalWeightLoss;
	}

	public String getMostLostProduct() {
		return MostLostProduct;
	}

	public void setMostLostProduct(String mostLostProduct) {
		MostLostProduct = mostLostProduct;
	}

	public List<DetailReport> getDetailReports() {
		return DetailReports;
	}

	public void setDetailReports(List<DetailReport> detailReports) {
		DetailReports = detailReports;
	}
}

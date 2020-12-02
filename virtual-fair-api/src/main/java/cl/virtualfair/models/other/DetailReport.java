package cl.virtualfair.models.other;

import java.time.LocalDateTime;

public class DetailReport {

	private long IdPurchaseRequest;
	
	private String Product;
	
	private double Weight;
	
	private String Client;
	
	private LocalDateTime Date;

	private long CostLoss;
	
	public DetailReport() {
		
	}
	

	public DetailReport(long idPurchaseRequest, String product, double weight, String client, LocalDateTime date,
			long costLoss) {
		IdPurchaseRequest = idPurchaseRequest;
		Product = product;
		Weight = weight;
		Client = client;
		Date = date;
		CostLoss = costLoss;
	}



	public long getIdPurchaseRequest() {
		return IdPurchaseRequest;
	}

	public void setIdPurchaseRequest(long idPurchaseRequest) {
		IdPurchaseRequest = idPurchaseRequest;
	}

	public String getProduct() {
		return Product;
	}

	public void setProduct(String product) {
		Product = product;
	}

	public double getWeight() {
		return Weight;
	}

	public void setWeight(double weight) {
		Weight = weight;
	}

	public String getClient() {
		return Client;
	}

	public void setClient(String client) {
		Client = client;
	}

	public LocalDateTime getDate() {
		return Date;
	}

	public void setDate(LocalDateTime date) {
		Date = date;
	}

	public long getCostLoss() {
		return CostLoss;
	}

	public void setCostLoss(long costLoss) {
		CostLoss = costLoss;
	}
}



package cl.virtualfair.services.other;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.other.DetailReport;
import cl.virtualfair.models.virtualfair.PurchaseRequestProduct;
import cl.virtualfair.services.virtualfair.PurchaseRequestProductService;

@Service
public class DetailReportService {

	@Autowired
	private PurchaseRequestProductService purchaseRequestProductService;
	
	public DetailReportService() {
		
	}
	
	public List<DetailReport> findByIdPurchaseRequestStatusInTwoNineAndUpdateDate(String updateDateOf, String updateDateTo){
		
		List<DetailReport> detailReports = new ArrayList<DetailReport>();
		
		List<PurchaseRequestProduct> purchaseRequestProducts = purchaseRequestProductService.findByIdPurchaseRequestStatusInTwoNineAndUpdateDate(updateDateOf, updateDateTo);
		
		for (PurchaseRequestProduct purchaseRequestProduct : purchaseRequestProducts) {
			
			DetailReport detailReport = new DetailReport();

			detailReport.setClient(purchaseRequestProduct.getPurchaseRequest().getClient().getFullName());
			detailReport.setCostLoss(purchaseRequestProduct.getAgreedPrice());
			detailReport.setDate(purchaseRequestProduct.getPurchaseRequest().getUpdateDate());
			detailReport.setIdPurchaseRequest(purchaseRequestProduct.getIdPurchaseRequest());
			detailReport.setProduct(purchaseRequestProduct.getProduct().getName());
			detailReport.setWeight(purchaseRequestProduct.getWeight());
			
			detailReports.add(detailReport);
		}
		
		return detailReports;
	}
}

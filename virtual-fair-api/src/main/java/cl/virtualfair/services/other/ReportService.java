package cl.virtualfair.services.other;

import java.time.format.DateTimeFormatter;
import java.util.List;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.PurchaseRequest;
import cl.virtualfair.models.virtualfair.PurchaseRequestProducer;
import cl.virtualfair.models.virtualfair.TransportAuctionCarrier;
import cl.virtualfair.models.virtualfair.User;
import cl.virtualfair.services.virtualfair.PurchaseRequestProducerService;
import cl.virtualfair.services.virtualfair.PurchaseRequestService;
import cl.virtualfair.services.virtualfair.TransportAuctionCarrierService;

@Service
public class ReportService {

	@Autowired
	private PurchaseRequestService purchaseRequestService;
	
	@Autowired
	private PurchaseRequestProducerService purchaseRequestProducerService;
	
	@Autowired
	private TransportAuctionCarrierService transportAuctionCarrierService;
	
	@Autowired
	private EmailService emailService;
	
	public ReportService() {
		
	}
	
	public Boolean existsParticipantsByIdPurchaseRequest(long idPurchaseRequest) {
	
		Boolean result = false;
		
		PurchaseRequest purchaseRequest = purchaseRequestService.findById(idPurchaseRequest);
		
		if(purchaseRequest != null) {
			
			List<PurchaseRequestProducer> purchaseRequestProducers = purchaseRequestProducerService.findByIdPurchaseRequestAndIsParticipantEqualToOne(idPurchaseRequest);
			
			TransportAuctionCarrier transportAuctionCarrier = transportAuctionCarrierService.findByIdPurchaseRequestAndIsParticipantEqualToOne(idPurchaseRequest);
			
			if(purchaseRequestProducers.size() > 0 || transportAuctionCarrier != null) {
		
				result = true;
				
			}
		}
		
		return result;
	}
	
	public Boolean sendReportToParticipantsByIdPurchaseRequest(long idPurchaseRequest) {
		
		Boolean result = false;
		
		PurchaseRequest purchaseRequest = purchaseRequestService.findById(idPurchaseRequest);
		
		if(purchaseRequest != null) {
			
			List<PurchaseRequestProducer> purchaseRequestProducers = purchaseRequestProducerService.findByIdPurchaseRequestAndIsParticipantEqualToOne(idPurchaseRequest);
			
			TransportAuctionCarrier transportAuctionCarrier = transportAuctionCarrierService.findByIdPurchaseRequestAndIsParticipantEqualToOne(idPurchaseRequest);
			
			if(purchaseRequestProducers.size() > 0) {
				
				List<User> producers = purchaseRequestProducers.stream().collect(Collectors.groupingBy(x -> x.getIdProducer())).values().stream().map(x -> x.stream().findFirst().get().getProducer()).collect(Collectors.toList());
				
				for (User producer : producers) {
				
					long totalPrice = purchaseRequestProducers.stream().filter(x -> x.getIdProducer() == producer.getId()).mapToLong(x -> x.getPrice()).sum();
					
					String message = "Estimado/a " + producer.getFullName() + "\n Se completo la venta " + idPurchaseRequest + " del cliente " + purchaseRequest.getClient().getFullName() + " en la fecha " + purchaseRequest.getUpdateDate().format(DateTimeFormatter.ofPattern("yyyy-MM-dd")) + " y ganó un total de $" + totalPrice + " pesos.";
					
					sendReport(producer.getEmail(), message, idPurchaseRequest);
					
				}
			}
			
			if(transportAuctionCarrier != null) {
				
				User carrier = transportAuctionCarrier.getCarrier();
				
				long totalPrice = transportAuctionCarrier.getPrice();
				
				String message = "Estimado/a " + carrier.getFullName() + "\n Se completo la venta " + idPurchaseRequest + " del cliente " + purchaseRequest.getClient().getFullName() + " en la fecha " + purchaseRequest.getUpdateDate().format(DateTimeFormatter.ofPattern("yyyy-MM-dd")) + " y ganó un total de $" + totalPrice + " pesos.";
				
				sendReport(carrier.getEmail(), message, idPurchaseRequest);
			}
			
			result = true;
		}
		
		return result;
	}
	
	private Boolean sendReport(String to, String message, long idPurchaseRequest) {
		
		String subject = "Reporte de Ganancias Venta " + idPurchaseRequest;
		
		Boolean result = emailService.sendEmail(to, subject, message);
		
		return result;
		
	}
}

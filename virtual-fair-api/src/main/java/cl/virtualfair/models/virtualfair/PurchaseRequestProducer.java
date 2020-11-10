package cl.virtualfair.models.virtualfair;

import java.io.Serializable;
import java.time.LocalDateTime;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

import org.hibernate.annotations.Proxy;

@Entity
@Table(name="PURCHASE_REQUEST_PRODUCER")
@Proxy(lazy=false)
public class PurchaseRequestProducer implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE ,generator="PURCHASE_REQUEST_PRODUCER_SEQ")
	@SequenceGenerator(name="PURCHASE_REQUEST_PRODUCER_SEQ", sequenceName="PURCHASE_REQUEST_PRODUCER_SEQ", allocationSize=1)
	@Column(name="ID")
	private Long Id;
	
	@Column(name="ID_PURCHASE_REQUEST_PRODUCT")
	private Long IdPurchaseRequestProduct;
	
	@Column(name="ID_PRODUCER")
	private Long IdProducer;
	
	@Column(name="WEIGHT")
	private Double Weight;
	
	@Column(name="PRICE")
	private Long Price;
	
	@Column(name="EXPIRATION_DATE")
	private LocalDateTime ExpirationDate;
	
	@Column(name="IS_PARTICIPANT")
	private Integer IsParticipant;
	
    @JoinColumn(name="ID_PURCHASE_REQUEST_PRODUCT", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private PurchaseRequestProduct PurchaseRequestProduct;
    
    @JoinColumn(name="ID_PRODUCER", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private User Producer;

	public PurchaseRequestProducer() {
	}    
    
	public PurchaseRequestProducer(Long id) {
		Id = id;
	}

	public PurchaseRequestProducer(Long id, Long idPurchaseRequestProduct, Long idProducer, Double weight, Long price,
			LocalDateTime expirationDate, Integer isParticipant,
			cl.virtualfair.models.virtualfair.PurchaseRequestProduct purchaseRequestProduct, User producer) {
		Id = id;
		IdPurchaseRequestProduct = idPurchaseRequestProduct;
		IdProducer = idProducer;
		Weight = weight;
		Price = price;
		ExpirationDate = expirationDate;
		IsParticipant = isParticipant;
		PurchaseRequestProduct = purchaseRequestProduct;
		Producer = producer;
	}

	public Long getId() {
		return Id;
	}

	public void setId(Long id) {
		Id = id;
	}

	public Long getIdPurchaseRequestProduct() {
		return IdPurchaseRequestProduct;
	}

	public void setIdPurchaseRequestProduct(Long idPurchaseRequestProduct) {
		IdPurchaseRequestProduct = idPurchaseRequestProduct;
	}

	public Long getIdProducer() {
		return IdProducer;
	}

	public void setIdProducer(Long idProducer) {
		IdProducer = idProducer;
	}

	public Double getWeight() {
		return Weight;
	}

	public void setWeight(Double weight) {
		Weight = weight;
	}

	public Long getPrice() {
		return Price;
	}

	public void setPrice(Long price) {
		Price = price;
	}

	public LocalDateTime getExpirationDate() {
		return ExpirationDate;
	}

	public void setExpirationDate(LocalDateTime expirationDate) {
		ExpirationDate = expirationDate;
	}

	public Integer getIsParticipant() {
		return IsParticipant;
	}

	public void setIsParticipant(Integer isParticipant) {
		IsParticipant = isParticipant;
	}

	public PurchaseRequestProduct getPurchaseRequestProduct() {
		return PurchaseRequestProduct;
	}

	public void setPurchaseRequestProduct(PurchaseRequestProduct purchaseRequestProduct) {
		PurchaseRequestProduct = purchaseRequestProduct;
	}

	public User getProducer() {
		return Producer;
	}

	public void setProducer(User producer) {
		Producer = producer;
	}
}

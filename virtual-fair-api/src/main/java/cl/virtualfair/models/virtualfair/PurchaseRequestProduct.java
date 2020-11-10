package cl.virtualfair.models.virtualfair;

import java.io.Serializable;

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
@Table(name="PURCHASE_REQUEST_PRODUCT")
@Proxy(lazy=false)
public class PurchaseRequestProduct implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE ,generator="PURCHASE_REQUEST_PRODUCT_SEQ")
	@SequenceGenerator(name="PURCHASE_REQUEST_PRODUCT_SEQ", sequenceName="PURCHASE_REQUEST_PRODUCT_SEQ", allocationSize=1)
	@Column(name="ID")
	private Long Id;
	
	@Column(name="ID_PURCHASE_REQUEST")
	private Long IdPurchaseRequest;
	
	@Column(name="ID_PRODUCT")
	private Long IdProduct;
	
	@Column(name="WEIGHT")
	private Double Weight;
	
	@Column(name="REMARK")
	private String Remark;
	
	@Column(name="AGREED_PRICE")
	private long AgreedPrice;
	
	@Column(name="REQUIRES_REFRIGERATION")
	private Integer RequiresRefrigeration;
	
    @JoinColumn(name="ID_PURCHASE_REQUEST", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private PurchaseRequest PurchaseRequest;
    
    @JoinColumn(name="ID_PRODUCT", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private Product Product;

	public PurchaseRequestProduct() {
	}    
    
	public PurchaseRequestProduct(Long id) {
		Id = id;
	}

	public PurchaseRequestProduct(Long id, Long idPurchaseRequest, Long idProduct, Double weight, String remark,
			long agreedPrice, Integer requiresRefrigeration,
			cl.virtualfair.models.virtualfair.PurchaseRequest purchaseRequest,
			cl.virtualfair.models.virtualfair.Product product) {
		Id = id;
		IdPurchaseRequest = idPurchaseRequest;
		IdProduct = idProduct;
		Weight = weight;
		Remark = remark;
		AgreedPrice = agreedPrice;
		RequiresRefrigeration = requiresRefrigeration;
		PurchaseRequest = purchaseRequest;
		Product = product;
	}

	public Long getId() {
		return Id;
	}

	public void setId(Long id) {
		Id = id;
	}

	public Long getIdPurchaseRequest() {
		return IdPurchaseRequest;
	}

	public void setIdPurchaseRequest(Long idPurchaseRequest) {
		IdPurchaseRequest = idPurchaseRequest;
	}

	public Long getIdProduct() {
		return IdProduct;
	}

	public void setIdProduct(Long idProduct) {
		IdProduct = idProduct;
	}

	public Double getWeight() {
		return Weight;
	}

	public void setWeight(Double weight) {
		Weight = weight;
	}

	public String getRemark() {
		return Remark;
	}

	public void setRemark(String remark) {
		Remark = remark;
	}

	public long getAgreedPrice() {
		return AgreedPrice;
	}

	public void setAgreedPrice(long agreedPrice) {
		AgreedPrice = agreedPrice;
	}

	public Integer getRequiresRefrigeration() {
		return RequiresRefrigeration;
	}

	public void setRequiresRefrigeration(Integer requiresRefrigeration) {
		RequiresRefrigeration = requiresRefrigeration;
	}

	public PurchaseRequest getPurchaseRequest() {
		return PurchaseRequest;
	}

	public void setPurchaseRequest(PurchaseRequest purchaseRequest) {
		PurchaseRequest = purchaseRequest;
	}

	public Product getProduct() {
		return Product;
	}

	public void setProduct(Product product) {
		Product = product;
	}
	
}

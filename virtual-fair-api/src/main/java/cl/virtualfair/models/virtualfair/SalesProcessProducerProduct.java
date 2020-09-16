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
@Table(name="SALES_PROCESS_PRODUCER_PRODUCT")
@Proxy(lazy=false)
public class SalesProcessProducerProduct implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE ,generator="SALES_PROCESS_PRODUCER_PRODUCT_SEQ")
	@SequenceGenerator(name="SALES_PROCESS_PRODUCER_PRODUCT_SEQ", sequenceName="SALES_PROCESS_PRODUCER_PRODUCT_SEQ", allocationSize=1)
	@Column(name="ID")
	private long Id;
	
	@Column(name="ID_SALES_PROCESS")
	private long IdSalesProcess;
	
	@Column(name="ID_PRODUCER")
	private long IdProducer;
	
	@Column(name="ID_PRODUCT")
	private long IdProduct;
	
	@Column(name="PRICE")
	private long Price;
	
	@Column(name="WEIGHT")
	private double Weight;
	
    @JoinColumn(name="ID_SALES_PROCESS", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private SalesProcess SalesProcess;
    
    @JoinColumn(name="ID_PRODUCER", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private User Producer;
    
    @JoinColumn(name="ID_PRODUCT", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private Product Product;

	public SalesProcessProducerProduct() {
	}    
    
	public SalesProcessProducerProduct(long id) {
		Id = id;
	}

	public SalesProcessProducerProduct(long id, long idSalesProcess, long idProducer, long idProduct, long price,
			double weight, cl.virtualfair.models.virtualfair.SalesProcess salesProcess, User producer,
			cl.virtualfair.models.virtualfair.Product product) {
		Id = id;
		IdSalesProcess = idSalesProcess;
		IdProducer = idProducer;
		IdProduct = idProduct;
		Price = price;
		Weight = weight;
		SalesProcess = salesProcess;
		Producer = producer;
		Product = product;
	}

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public long getIdSalesProcess() {
		return IdSalesProcess;
	}

	public void setIdSalesProcess(long idSalesProcess) {
		IdSalesProcess = idSalesProcess;
	}

	public long getIdProducer() {
		return IdProducer;
	}

	public void setIdProducer(long idProducer) {
		IdProducer = idProducer;
	}

	public long getIdProduct() {
		return IdProduct;
	}

	public void setIdProduct(long idProduct) {
		IdProduct = idProduct;
	}

	public long getPrice() {
		return Price;
	}

	public void setPrice(long price) {
		Price = price;
	}

	public double getWeight() {
		return Weight;
	}

	public void setWeight(double weight) {
		Weight = weight;
	}

	public SalesProcess getSalesProcess() {
		return SalesProcess;
	}

	public void setSalesProcess(SalesProcess salesProcess) {
		SalesProcess = salesProcess;
	}

	public User getProducer() {
		return Producer;
	}

	public void setProducer(User producer) {
		Producer = producer;
	}

	public Product getProduct() {
		return Product;
	}

	public void setProduct(Product product) {
		Product = product;
	}
}

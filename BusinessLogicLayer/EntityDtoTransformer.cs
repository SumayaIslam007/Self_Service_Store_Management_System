using BusinessLogicLayer.Dtos;
using DataAccessLayer.Entities;
using System;

namespace BusinessLogicLayer
{
    public class EntityDtoTransformer
    {
        // Method to transform Admin entity to AdminDto
        public AdminDto TransformToAdminDto(Admin admin)
        {
            if (admin == null)
            {
                return null;
            }

            return new AdminDto
            {
                Id = admin.Id,
                Name = admin.Name,
                Email = admin.Email,
                Phone = admin.Phone,
                Type = admin.Type,
                Password = admin.Password
            };
        }

        // Method to transform AdminDto to Admin entity
        public Admin TransformToAdminEntity(AdminDto adminDto)
        {
            if (adminDto == null)
            {
                return null;
            }

            return new Admin
            {
                Id = adminDto.Id,
                Name = adminDto.Name,
                Email = adminDto.Email,
                Phone = adminDto.Phone,
                Type = adminDto.Type,
                Password = adminDto.Password
            };
        }

        // Method to transform Customer entity to CustomerDto
        public CustomerDto TransformToCustomerDto(Customer customer)
        {
            if (customer == null)
            {
                return null;
            }

            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Password = customer.Password
            };
        }

        // Method to transform CustomerDto to Customer entity
        public Customer TransformToCustomerEntity(CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return null;
            }

            return new Customer
            {
                Id = customerDto.Id,
                Name = customerDto.Name,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
                Password = customerDto.Password
            };
        }

        // Method to transform Membership entity to MembershipDto
        public MembershipDto TransformToMembershipDto(Membership membership)
        {
            if (membership == null)
            {
                return null;
            }

            return new MembershipDto
            {
                Id = membership.Id,
                CustomerId = membership.CustomerId,
                MembershipType = membership.MembershipType,
                DiscountRate = membership.DiscountRate,
                StartDate = membership.StartDate,
                EndDate = membership.EndDate
            };
        }

        // Method to transform MembershipDto to Membership entity
        public Membership TransformToMembershipEntity(MembershipDto membershipDto)
        {
            if (membershipDto == null)
            {
                return null;
            }

            return new Membership
            {
                Id = membershipDto.Id,
                CustomerId = membershipDto.CustomerId,
                MembershipType = membershipDto.MembershipType,
                DiscountRate = membershipDto.DiscountRate,
                StartDate = membershipDto.StartDate,
                EndDate = membershipDto.EndDate
            };
        }

        // Method to transform Product entity to ProductDto
        public ProductDto TransformToProductDto(Product product)
        {
            if (product == null)
            {
                return null;
            }

            return new ProductDto
            {
                Id = product.Id,
                ProductCode = product.ProductCode,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }

        // Method to transform ProductDto to Product entity
        public Product TransformToProductEntity(ProductDto productDto)
        {
            if (productDto == null)
            {
                return null;
            }

            return new Product
            {
                Id = productDto.Id,
                ProductCode = productDto.ProductCode,
                Name = productDto.Name,
                Description = productDto.Description,
                Category = productDto.Category,
                Price = productDto.Price,
                Quantity = productDto.Quantity
            };
        }

        // Method to transform Transaction entity to TransactionDto
        public TransactionDto TransformToTransactionDto(Transaction transaction)
        {
            if (transaction == null)
            {
                return null;
            }

            return new TransactionDto
            {
                Id = transaction.Id,
                CustomerId = transaction.CustomerId,
                Date = transaction.Date,
                ProductName = transaction.ProductName,
                Amount = transaction.Amount,
                PaymentMethod = transaction.PaymentMethod
            };
        }

        // Method to transform TransactionDto to Transaction entity
        public Transaction TransformToTransactionEntity(TransactionDto transactionDto)
        {
            if (transactionDto == null)
            {
                return null;
            }

            return new Transaction
            {
                Id = transactionDto.Id,
                CustomerId = transactionDto.CustomerId,
                Date = transactionDto.Date,
                ProductName= transactionDto.ProductName,
                Amount = transactionDto.Amount,
                PaymentMethod = transactionDto.PaymentMethod
            };
        }
    }
}

using BusinessLogicLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
    public interface ITransactionManager
    {
        List<TransactionDto> GetAllTransactions();
        TransactionDto GetTransactionById(int id);
        void AddTransaction(TransactionDto transactionDto);
        void UpdateTransaction(TransactionDto transactionDto);
        void DeleteTransaction(int id);
    }
}

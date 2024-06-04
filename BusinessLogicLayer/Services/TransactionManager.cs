using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class TransactionManager : ITransactionManager
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly EntityDtoTransformer _transformer;

        public TransactionManager()
        {
            _transactionRepository = new TransactionRepository();
            _transformer = new EntityDtoTransformer();
        }

        public List<TransactionDto> GetAllTransactions()
        {
            List<Transaction> transactions = _transactionRepository.GetAllTransactions();
            List<TransactionDto> transactionDtos = new List<TransactionDto>();
            foreach (var transaction in transactions)
            {
                transactionDtos.Add(_transformer.TransformToTransactionDto(transaction));
            }
            return transactionDtos;
        }

        public TransactionDto GetTransactionById(int id)
        {
            Transaction transaction = _transactionRepository.GetTransactionById(id);
            return _transformer.TransformToTransactionDto(transaction);
        }

        public void AddTransaction(TransactionDto transactionDto)
        {
            Transaction transaction = _transformer.TransformToTransactionEntity(transactionDto);
            _transactionRepository.AddTransaction(transaction);
        }

        public void UpdateTransaction(TransactionDto transactionDto)
        {
            Transaction transaction = _transformer.TransformToTransactionEntity(transactionDto);
            _transactionRepository.UpdateTransaction(transaction);
        }

        public void DeleteTransaction(int id)
        {
            _transactionRepository.DeleteTransaction(id);
        }
    }
}

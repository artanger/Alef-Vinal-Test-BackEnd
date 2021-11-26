using System.Collections.Generic;
using System.Linq;
using DAL.Abstractions;
using DAL.Models;

namespace DAL.Repositories
{
    public class CodeRepository : ICodeRepository
    {
        private readonly AlefVinalDbContext _dbContext;

        public CodeRepository()
        {
            _dbContext = new DbContextFactory().CreateDbContext(new []{string.Empty});
        }

        /// <summary>
        /// Gets all Code entities
        /// </summary>
        /// <returns>List of Code entities</returns>
        public IEnumerable<Code> GetAllCodes()
        {
            return _dbContext.Code;
        }

        /// <summary>
        /// Gets the Code entity by identifier
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns>The Code entity</returns>
        public Code GetCode(int id)
        {
            return _dbContext.Code.FirstOrDefault(x => x.Id == id) ?? new Code {Id = -1} /* -1: Not found */;
        }

        /// <summary>
        /// Adds new Code entity
        /// </summary>
        /// <param name="code">The Code entity to add</param>
        /// <returns>The number of objects written to the underlying database.</returns>
        public int AddCode(Code code)
        {
            _dbContext.Code.Add(code);

            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// Removes code rom DB by identifier
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns>The number of objects written to the underlying database</returns>
        public int DeleteCode(int id)
        {
            var code = GetCode(id);
            if (code == null || code.Id == -1)
            {
                // -1: Not found
                return -1; 
            }

            _dbContext.Code.Remove(code);

            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// Updates code in DB
        /// </summary>
        /// <param name="code">The Code entity to update</param>
        /// <returns>The number of objects written to the underlying database</returns>
        public int UpdateCode(Code code)
        {
            var existingCode = GetCode(code.Id);
            if (existingCode == null || existingCode.Id == -1)
            {
                // -1: Not found
                return -1;
            }

            existingCode.Value = code.Value;
            existingCode.Name = code.Name;

            return _dbContext.SaveChanges();
        }
    }
}

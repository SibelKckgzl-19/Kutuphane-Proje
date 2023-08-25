using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSP.Model.Dtos.BType;
using WSP.Model.Entities;

namespace WSP.Business.Interfaces
{
     public interface IBTypeBs
    {
        ApiResponse<List<BTypeGetDto>> GetBTypes(params string[] includeList);
        ApiResponse<List<BTypeGetDto>> GetBTypesByBookName(string bookName, params string[] includeList);
        ApiResponse<List<BTypeGetDto>> GetBTypesByBookType(string bookType, params string[] includeList);
        ApiResponse<List<BTypeGetDto>> GetBTypesByBook(int bookID, params string[] includeList);

        ApiResponse<BTypeGetDto> GetByID(int bookTypeID, params string[] includeList);

        ApiResponse<BType> Insert (BTypePostDto dto);
        ApiResponse<NoData> Update (BTypePutDto dto);
        ApiResponse<NoData> Delete (int id);
    }
}

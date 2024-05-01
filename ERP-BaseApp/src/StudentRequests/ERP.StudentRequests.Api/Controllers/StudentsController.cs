﻿using ERP.StudentRequests.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ERP.StudentRequests.Core.DTOs.Request;
using ERP.StudentRequests.Core.DTOs.Response;
using ERP.StudentRequests.Core.Entity;

namespace ERP.StudentRequests.Api.Controllers
{
    public class StudentsController : BaseController
    {
        public StudentsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{studentId:guid}")]
        public async Task<IActionResult> GetStudentMethod(Guid studentId)
        {
            var student = await _unitOfWork.Students.GetById(studentId);

            if (student == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetStudentResponse>(student);

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddStudentMethod([FromBody] CreateStudentRequest student)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Student>(student);

            await _unitOfWork.Students.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetStudentMethod), new { studentId = result.Id }, result);

        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateStudentMethod([FromBody] UpdateStudentRequest student)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Student>(student);

            await _unitOfWork.Students.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();

        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentsMethod()
        {
            var student = await _unitOfWork.Students.GetAll();

            return Ok(_mapper.Map<IEnumerable<GetStudentResponse>>(student));
        }

        [HttpDelete]
        [Route("{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentMethod(Guid studentId)
        {
            var student = await _unitOfWork.Students.GetById(studentId);

            if (student == null)
            {
                return NotFound();
            }

            await _unitOfWork.Students.Delete(studentId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}

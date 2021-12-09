﻿using Core.Business.Interfaces;
using Core.Mapper;
using Core.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private readonly ICommentBusiness _business;
        private readonly IEntityMapper _mapper;
        public CommentsController(ICommentBusiness business, IEntityMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        [Authorize(Roles = ("Admin"))]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var comments = _business.GetAll().Result;

                return Ok(_mapper.MappComments(comments));
            }
            catch (Exception e)
            {
                return StatusCode(400, e);
            }
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(CommentDtoForCreation), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddComment(CommentDtoForCreation comment)
        {
            try
            {
                _business.AddComment(comment);

                return new JsonResult(comment) { StatusCode = 201 };
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }
    }
}

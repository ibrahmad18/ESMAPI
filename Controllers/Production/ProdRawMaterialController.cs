﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProdRawMaterial;

namespace ServiceManagerApi.Controllers.Production
{
     public class ProdRawMaterialController : BaeApiController<ProdRawMaterialController>
    {
        private readonly EnpDBContext _context;
        public ProdRawMaterialController(EnpDBContext context)
        {
            _context = context;
        }

        //get list
        [HttpGet]
        [ProducesResponseType(typeof(ProdRawMaterial), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<ProdRawMaterial>> Get()
        {
            return await _context.ProdRawMaterials.ToListAsync();
        }

        // get by id
        [HttpGet("id")]
        [ProducesResponseType(typeof(ProdRawMaterial), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var prodRawMaterial = await _context.ProdRawMaterials.FindAsync(id);
            if (prodRawMaterial == null)
            {
                return NotFound();
            }
            return Ok(prodRawMaterial);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProdRawMaterial), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(ProdRawMaterialPostDto prodRawMaterialPostDto)
        {
            ProdRawMaterial prodRawMaterial = _mapper.Map<ProdRawMaterial>(prodRawMaterialPostDto);
            _context.ProdRawMaterials.Add(prodRawMaterial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProdRawMaterialExists(prodRawMaterial.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = prodRawMaterial.Id }, prodRawMaterial);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProdRawMaterial), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, ProdRawMaterial prodRawMaterial)
        {
            if(id != prodRawMaterial.Id)
            {
                return BadRequest();
            }

            _context.Entry(prodRawMaterial).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdRawMaterialExists(prodRawMaterial.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ProdRawMaterial), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var prodRawMaterial = await _context.ProdRawMaterials.FindAsync(id);
            if (prodRawMaterial == null)
            {
                return NotFound();
            }
            _context.ProdRawMaterials.Remove(prodRawMaterial);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProdRawMaterialExists(int id)
        {
            return _context.ProdRawMaterials.Any(e => e.Id == id);
        }
    }
}
